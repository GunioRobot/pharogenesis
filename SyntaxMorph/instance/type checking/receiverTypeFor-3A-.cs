receiverTypeFor: aSelector
	"Answer the type of the receiver of this selector.  Return #unknown if not found."

	| itsInterface |

	aSelector ifNil: [^ #unknown].
	itsInterface _ self currentVocabulary methodInterfaceAt: aSelector ifAbsent:
		[^ #unknown].
	^ itsInterface receiverType