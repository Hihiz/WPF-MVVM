# пакет  Microsoft.Xaml.Behaviors.Wpf         
         
         xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
             
          <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseDoubleClick">
                        <i:InvokeCommandAction Command="{Binding EditUserCommand}" CommandParameter="{Binding ElementName=listViewUser, Path=SelectedItem}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
