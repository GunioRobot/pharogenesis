pier
	"Create a Gofer instance of Pier."

	^ self new
		renggli: 'pier';
		addPackage: 'Pier-Model';
		addPackage: 'Pier-Tests';
		addPackage: 'Pier-Seaside';
		addPackage: 'Pier-Blog';
		addPackage: 'Pier-Security';
		addPackage: 'Pier-Squeak-Persistency';
		yourself