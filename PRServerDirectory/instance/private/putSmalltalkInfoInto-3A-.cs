putSmalltalkInfoInto: args 
	"private - fills args with information from Smalltalk"
	self flag: #todo.
	" 
	lastest small-land changeset / small-land version  
	"
	#(#datedVersion #osVersion #platformName #platformSubtype #vmPath #vmVersion #imageName #changesName #sourcesName #listBuiltinModules #listLoadedModules #getVMParameters )
		do: [:each | 
			| value | 
			value := SmalltalkImage current perform: each.
			args at: 'extra-' , each asString put: {value asString}]