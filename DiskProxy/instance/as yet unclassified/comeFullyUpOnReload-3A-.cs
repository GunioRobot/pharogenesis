comeFullyUpOnReload: smartRefStream
	"Internalize myself into a fully alive object after raw loading from a DataStream. (See my class comment.)  DataStream will substitute the object from this eval for the DiskProxy."
	| globalObj symbol pr nn arrayIndex |

	symbol _ globalObjectName.
	"See if class is mapped to another name"
	(smartRefStream respondsTo: #renamed) ifTrue: [
		"If in outPointers in an ImageSegment, remember original class name.  
		 See mapClass:installIn:.  Would be lost otherwise."
		((thisContext sender sender sender sender sender sender 
			sender sender receiver class == ImageSegment) and: [ 
		thisContext sender sender sender sender method == 
			(DataStream compiledMethodAt: #readArray)]) ifTrue: [
				arrayIndex _ (thisContext sender sender sender sender) tempAt: 4.
					"index var in readArray.  Later safer to find i on stack of context."
				smartRefStream renamedConv at: arrayIndex put: symbol].	"save original name"
		symbol _ smartRefStream renamed at: symbol ifAbsent: [symbol]].	"map"
	globalObj _ Smalltalk at: symbol 
		ifAbsent: [^ self error: 'Global not found'].
	((symbol == #World) and: [Smalltalk isMorphic not]) ifTrue: [
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