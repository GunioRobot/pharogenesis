tools
	"Create a Gofer instance of several development tools."

	^ self new
		renggli: 'unsorted';
		addPackage: 'Shout';
		addPackage: 'RoelTyper';
		addPackage: 'ECompletion';
		addPackage: 'ECompletionOmniBrowser';
		yourself