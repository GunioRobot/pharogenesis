findStacks
	"Return an array of all the StackMorphs in this project."

| guys stacks |
guys _ StackMorph withAllSubclasses asIdentitySet.
stacks _ OrderedCollection new.
arrayOfRoots do: [:obj |
	(guys includes: obj class) ifTrue: [stacks add: obj]].
^ stacks