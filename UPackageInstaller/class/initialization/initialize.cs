initialize
	Installers ifNil: [ Installers _ Set new ].
	
	{UIFileOut. UIMonticello. UIMpeg. UIProject. UISar} do: [ :c |
		self registerInstaller: c new ]