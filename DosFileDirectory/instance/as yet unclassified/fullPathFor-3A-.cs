fullPathFor: path
	"Return the fully-qualified path name for the given file."
	path isEmpty ifTrue:[^pathName].
	(path at: 1) = $\ ifTrue:[
		(path size >= 2 and:[(path at: 2) = $\]) ifTrue:[^path]. "e.g., \\pipe\"
		^(pathName copyFrom: 1 to: 2), path "e.g., \windows\"].
	(path size >= 2 and:[(path at: 2) = $: and:[path first isLetter]])
		ifTrue:[^path]. "e.g., c:"
	^pathName, self slash, path