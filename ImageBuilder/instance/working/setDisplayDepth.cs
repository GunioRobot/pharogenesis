setDisplayDepth
	" 
	FullImageTools new setDisplayDepth.
	"
	Project allInstances
		do: [:each | each displayDepth: 32].
	Display newDepth: 32