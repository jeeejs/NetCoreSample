import { login, getToken, getUser } from "../src/services/auth";

test('Login valido', async () => {
    const data = await login("user@mail.com","123");
    expect(data.success).toBe(true);
});

test('Login invalido', async () => {
    const data = await login("user@mail.com","124");
    expect(data.success).toBe(false);
});

test('Armazenou token', async () => {
    const data = await login("user@mail.com","123");
    expect(getToken()).not.toBeNull();
});

test('Usuario valido', async () => {
    await login("user@mail.com","123");
    const data = await getUser();
    expect(data.email).toMatch("user@mail.com");
});