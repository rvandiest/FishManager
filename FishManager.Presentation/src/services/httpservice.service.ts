export class HttpService {

    public static async post<T>(url: string, payload: T) {
        const fetchRes = await fetch(url, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'post',
            body: JSON.stringify(payload)
        });

        const jsonRes = await fetchRes.json();

        return (jsonRes as T);
    }

    public static async get<T>(url: string) {
        const fetchRes = await fetch(url);
        const jsonRes = await fetchRes.json();

        return (jsonRes as T);
    }
}