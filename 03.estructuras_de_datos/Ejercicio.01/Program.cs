
Cliente cliete = new Cliente()
{
    NombreCompleto = "Gabriel Lanza",
    Telefono = "(11) 6252-0101",
    Email = "gab@gmail.com",
    EsCliente = true,
    Direccion = new Direccion()
    {
        Altura = 861,
        Calle = "Dante Alighieri",
        Localidad = "Avellandeda",
        Provincia = "Buenos Aires"
    }
};

Console.WriteLine(cliete);


public struct Direccion
{
    public string Calle;
    public int Altura;

    public string Localidad;
    public string Provincia;

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}, {3}", Calle, Altura, Localidad, Provincia);
    }

}

public struct Cliente
{

    public Cliente(string nombreCompleto, string telefono, Direccion direccion, string email, bool esCliente)
    {
        this.NombreCompleto = nombreCompleto;
        this.Telefono = telefono;
        this.Direccion = direccion;
        this.Email = email;
        this.EsCliente = esCliente;
    }

    public string NombreCompleto;
    public string Telefono;
    public Direccion Direccion;
    public string Email;
    public bool EsCliente;

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}, {3}, {4}", NombreCompleto, Telefono, Direccion, Email, EsCliente);
    }

}
