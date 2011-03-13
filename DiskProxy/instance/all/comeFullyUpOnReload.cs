comeFullyUpOnReload
	"Internalize myself into a fully alive object after raw loading from a DataStream. (See my class comment.)  DataStream will substitute the object from this eval for the DiskProxy."
	| globalObj symbol reader |

	symbol _ globalObjectName.
	"See if class is mapped to another name"
	reader _ thisContext sender receiver.
	(reader respondsTo: #renamed) ifTrue: [
		symbol _ reader renamed at: symbol ifAbsent: [symbol]].
	globalObj _ Smalltalk at: symbol 
		ifAbsent: [^ self halt: 'Global not found'].
	Symbol hasInterned: constructorSelector ifTrue: [:selector |
		^ globalObj perform: selector
				withArguments: constructorArgs].	"(Renamed not checked by arg)"
	^ nil 	"was not in proper form"