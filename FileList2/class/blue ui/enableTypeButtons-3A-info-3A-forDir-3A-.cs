enableTypeButtons: typeButtons info: fileTypeInfo forDir: aDirectory

	| foundSuffixes fileSuffixes firstEnabled enableIt |

	firstEnabled _ nil.
	foundSuffixes _ (aDirectory ifNil: [ #()] ifNotNil: [ aDirectory fileNames]) collect: [ :each | (each findTokens: '.') last asLowercase].
	foundSuffixes _ foundSuffixes asSet.
	fileTypeInfo with: typeButtons do: [ :info :button |
		fileSuffixes _ info second.
		enableIt _ fileSuffixes anySatisfy: [ :patt | foundSuffixes includes: patt].
		button 
			setProperty: #enabled 
			toValue: enableIt.
		enableIt ifTrue: [firstEnabled ifNil: [firstEnabled _ button]].
	].
	firstEnabled ifNotNil: [^firstEnabled mouseUp: nil].
	typeButtons do: [ :each | each color: Color gray].

