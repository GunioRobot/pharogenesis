markMatchingClasses
	"If an example is used, mark classes matching the example instance with an asterisk."

	| unmarkedClassList firstPartOfSelector receiverString receiver |

	self flag: #mref.	"allows for old-fashioned style"

	"Only 'example' queries can be marked."
	(contents asString includes: $.) ifFalse: [^ self].

	unmarkedClassList _ classList copy.

	"Get the receiver object of the selected statement in the message list."
	firstPartOfSelector _ (Scanner new scanTokens: (selectorList at: selectorIndex)) second.
	receiverString _ (ReadStream on: (selectorList at: selectorIndex))
						upToAll: firstPartOfSelector.
	receiver _ Compiler evaluate: receiverString.

	unmarkedClassList do: [ :classAndMethod | | class |
		(classAndMethod isKindOf: MethodReference) ifTrue: [
			(receiver isKindOf: classAndMethod actualClass) ifTrue: [
				classAndMethod stringVersion: '*', classAndMethod stringVersion.
			]
		] ifFalse: [
			class _ Compiler evaluate:
					((ReadStream on: classAndMethod) upToAll: firstPartOfSelector).
			(receiver isKindOf: class) ifTrue: [
				classList add: '*', classAndMethod.
				classList remove: classAndMethod
			]
		].
	].