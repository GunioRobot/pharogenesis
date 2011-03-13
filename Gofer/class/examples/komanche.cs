komanche
	"Create a Gofer instance of Komanche."

	^ self new
		squeaksource: 'KomHttpServer';
		addPackage: 'DynamicBindings';
		addPackage: 'KomServices';
		addPackage: 'KomHttpServer';
		yourself