fullPathFor: path
	path isEmpty ifTrue:[^pathName].
	((path includes: $$ ) or:[path includes: $:]) ifTrue:[^path].
	^pathName, self slash, path