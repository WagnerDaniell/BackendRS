# Sistema de Reservas

Funcionalidades em dessenvolvimento...

1. Autenticação de Usuário

- Registro: O usuário deve ser capaz de se registrar com um nome, e-mail e senha.
- Login: Usuários autenticados recebem um token JWT para acesso às funcionalidades de reservas.
- Restrição de Acesso: Apenas usuários logados podem criar e visualizar reservas.

2. Gestão de Mesas

- Listagem: Listar todas as mesas disponíveis no restaurante.
- Criar Mesa: Administradores podem adicionar novas mesas ao sistema com um nome e capacidade de pessoas.
- Status da Mesa: Cada mesa pode estar disponível, reservada ou inativa.

3. Sistema de Reservas

- Criar Reserva: Usuários autenticados podem criar reservas para mesas específicas.
- Verificar Disponibilidade: A API deve verificar se a mesa está disponível no horário solicitado antes de confirmar a reserva.
- Cancelar Reserva: Usuários podem cancelar suas reservas, o que libera a mesa para novas reservas.

4. Controle de Status

- Status das Mesas: Mesas ficam reservadas automaticamente ao serem associadas a uma reserva.
- Status das Reservas: Reservas têm status ativo quando confirmadas e cancelado quando canceladas.# System Reservation
