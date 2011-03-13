omnibrowser
	"Create a Gofer instance of OmniBrowser."

	^ self new
		renggli: 'omnibrowser';
		addPackage: 'OmniBrowser';
		addPackage: 'OB-Standard';
		addPackage: 'OB-Morphic';
		addPackage: 'OB-Refactory';
		addPackage: 'OB-Regex';
		addPackage: 'OB-SUnitIntegration';
		yourself