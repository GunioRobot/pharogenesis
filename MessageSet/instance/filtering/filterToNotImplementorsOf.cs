filterToNotImplementorsOf
	"Filter the receiver's list down to only those items whose selector is NOT one solicited from the user."

	| aFragment inputWithBlanksTrimmed |

	aFragment _ FillInTheBlank request: 'type selector: ' initialAnswer: ''.
	aFragment  isEmptyOrNil ifTrue: [^ self].
	inputWithBlanksTrimmed _ aFragment withBlanksTrimmed.
	Symbol hasInterned: inputWithBlanksTrimmed ifTrue:
		[:aSymbol | 
			self filterFrom:
				[:aClass :aSelector |
					aSelector ~~ aSymbol]]