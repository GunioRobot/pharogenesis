new

	| new |

	new := super new.
	new setProjectHolder: CurrentProject.
	self addingProject: new.
	^new