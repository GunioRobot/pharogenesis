new

	| new |

	new _ super new.
	new setProjectHolder: CurrentProject.
	self addingProject: new.
	^new