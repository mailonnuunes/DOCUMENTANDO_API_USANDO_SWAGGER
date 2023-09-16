namespace APIAlura.Entity
{
    public class Pedido : Entidade
    {
        public string NomeProduto { get; set; }
        public int UsuarioId { get; set; }

        // Propriedade de navegação para o usuário
        public Usuario Usuario { get; set; }


        public Pedido()
        {
        
        
        }
        public Pedido(Pedido pedido) 
        { 
        
            NomeProduto = pedido.NomeProduto;
            UsuarioId = pedido.UsuarioId;
            
        }
    }
   
}
