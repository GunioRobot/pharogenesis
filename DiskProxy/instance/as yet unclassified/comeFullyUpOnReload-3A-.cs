comeFullyUpOnReload: smartRefStream
	"Internalize myself into a fully alive object after raw loading from a DataStream. (See my class comment.)  DataStream will substitute the object from this eval for the DiskProxy."
	| globalObj symbol pr nn |

	symbol _ globalObjectName.
	"See if class is mapped to another name"
	(smartRefStream respondsTo: #renamed) ifTrue: [
		symbol _ smartRefStream renamed at: symbol ifAbsent: [symbol]].
	globalObj _ Smalltalk at: symbol 
		ifAbsent: [^ self halt: 'Global not found'].
	((symbol == #World) and: [World == nil]) ifTrue: [
		self inform: 'These objects will work better if opened in a Morphic World.
Dismiss and reopen all menus.'].

	preSelector ifNotNil: [
		Symbol hasInterned: preSelector ifTrue: [:selector |
			globalObj _ globalObj perform: selector]].
	symbol == #Project ifTrue: [
		(constructorSelector = #fromUrl:) ifTrue: [
			nn _ (constructorArgs first findTokens: '/') last.
			nn _ (nn findTokens: '.|') first.
			pr _ Project named: nn. 
			^ pr ifNil: [self] ifNotNil: [pr]].
		pr _ globalObj perform: constructorSelector withArguments: constructorArgs.
		^ pr ifNil: [self] ifNotNil: [pr]].	"keep the Proxy if Project does not exist"

	constructorSelector ifNil: [^ globalObj].
	constructorSelector ifNotNil: [
		Symbol hasInterned: constructorSelector ifTrue: [:selector |
			^ globalObj perform: selector
					withArguments: constructorArgs]].
					"args not checked against Renamed"
	^ nil 	"was not in proper form"