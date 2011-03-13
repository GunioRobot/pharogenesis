translate: aString from: fromLang to: toLang
	| inputs |
	"Submit the string to the translation server at www.freetranslation.com.  Return the entire web page that freetranslation sends back."

	aString size >= 10000 ifTrue: [^ self inform: 'Text selection is too long.'].
	inputs _ Dictionary new.
	inputs at: 'SrcText' put: (Array with: aString).
	inputs at: 'Sequence' put: #('core').
	inputs at: 'Mode' put: #('html').
	inputs at: 'template' put: #('TextResult2.htm').
	inputs at: 'Language' put: (Array with: fromLang, '/', toLang).
	^ 'http://ets.freetranslation.com:5081' asUrl postFormArgs: inputs.
	
