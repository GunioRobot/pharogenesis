makeAllMaps 
	"Make a giant list of all permutations of the args.  To find the function, we will try these permutations of the input data.  receiver, args."

	| ii |
	mapList _ Array new: argMap size factorial.
	ii _ 1.
	argMap permutationsDo: [:perm |
		mapList at: ii put: perm copy.
		ii _ ii + 1].
	mapStage _ 1.	"about to be bumped"