saveDocCheck: aMorph
	"Make sure the document gets attached to the version of the code that the user was looking at.  Is there a version of this method in a changeSet beyond the updates we know about?  Works even when the user has internal update numbers and the documentation is for external updates (It always is)."

	| classAndMethod parts selector class lastUp beyond ours docFor unNum ok key verList ext response |
	classAndMethod _ aMorph valueOfProperty: #classAndMethod.
	classAndMethod ifNil: [
		^ self error: 'need to know the class and method'].	"later let user set it"
	parts _ classAndMethod findTokens: ' .'.
	selector _ parts last asSymbol.
	class _ Smalltalk at: (parts first asSymbol) ifAbsent: [^ self saveDoc: aMorph].
	parts size = 3 ifTrue: [class _ class class].
	"Four indexes we are looking for:
		docFor = highest numbered below lastUpdate that has method.
		unNum = a higher unnumbered set that has method.
		lastUp = lastUpdate we know about in methodVersions
		beyond = any set about lastUp that has the method."
	ChangeSorter allChangeSets doWithIndex: [:cs :ind | "youngest first"
		(cs name includesSubString: lastUpdateName) ifTrue: [lastUp _ ind].
		(cs atSelector: selector class: class) ~~ #none ifTrue: [
			lastUp ifNotNil: [beyond _ ind. ours _ cs name]
				ifNil: [cs name first isDigit ifTrue: [docFor _ ind] 
						ifFalse: [unNum _ ind. ours _ cs name]]]].
	"See if version the user sees is the version he is documenting"
	ok _ beyond == nil.
	unNum ifNotNil: [docFor ifNotNil: [ok _ docFor > unNum]
						ifNil: [ok _ false]].  "old changeSets gone"
	ok ifTrue: [^ self saveDoc: aMorph].

	key _ DocLibrary properStemFor: classAndMethod.
	verList _ (methodVersions at: key ifAbsent: [#()]), #(0 0).
	ext _ verList first.	"external update number we will write to"
	response _ (PopUpMenu labels: 'Cancel\Broadcast Page' withCRs)
				startUpWithCaption: 'You are documenting a method in External Update ', ext asString, '.\There is a more recent version of that method in ' withCRs, ours, 
'.\If you are explaining the newer version, please Cancel.\Wait until that version appears in an External Update.' withCRs.
	response = 2 ifTrue: [self saveDoc: aMorph].
