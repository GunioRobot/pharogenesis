pierAddons
	"Create a Gofer instance of Pier Addons."

	^ self new
		renggli: 'pieraddons';
		addPackage: 'Pier-Design';
		addPackage: 'Pier-Documents';
		addPackage: 'Pier-EditorEnh';
		addPackage: 'Pier-Google';
		addPackage: 'Pier-Links';
		addPackage: 'Pier-Randomizer';
		addPackage: 'Pier-TagCloud';
		addPackage: 'Pier-Slideshow';
		addPackage: 'Pier-Setup';
		yourself