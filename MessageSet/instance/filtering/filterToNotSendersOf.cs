filterToNotSendersOf
	"Filter the receiver's list down to only those items which do not send a given selector"

	| aFragment inputWithBlanksTrimmed aMethod |

	aFragment _ FillInTheBlank request: 'type selector:' initialAnswer: ''.
	aFragment  isEmptyOrNil ifTrue: [^ self].
	inputWithBlanksTrimmed _ aFragment withBlanksTrimmed.
	Symbol hasInterned: inputWithBlanksTrimmed ifTrue:
		[:aSymbol | 
			self filterFrom:
				[:aClass :aSelector |
					(aMethod _ aClass compiledMethodAt: aSelector) isNil or:
						[(aMethod hasLiteralThorough: aSymbol) not]]]