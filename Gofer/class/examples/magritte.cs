magritte
	"Create a Gofer instance of Magritte."

	^ self new
		renggli: 'magritte';
		addPackage: 'Magritte-Model';
		addPackage: 'Magritte-Tests';
		addPackage: 'Magritte-Seaside';
		addPackage: 'Magritte-Morph';
		yourself