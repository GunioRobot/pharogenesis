openScamperOn: currentSelection
	"Submit the string to the translation server at www.freetranslation.com.  Ask it to translate from (Preferences parameterAt: #languageTranslateFrom) to (Preferences parameterAt: #languageTranslateTo).  Display the results in a Scamper window, reusing the previous one if possible."

	| inputs scamperWindow from to | 
	currentSelection size >= 10000 ifTrue: [^ self inform: 'Text selection is too long.'].
	from _ Preferences parameterAt: #languageTranslateFrom ifAbsentPut: ['English'].
	to _ Preferences parameterAt: #languageTranslateTo ifAbsentPut: ['German'].
	from = to ifTrue:
			[^ self inform: 'You asked to translate from ', from, ' to ', to, '.\' withCRs,
				'Use "choose language" to set these.'].  
	inputs _ Dictionary new.
	inputs at: 'SrcText' put: (Array with: currentSelection).
	inputs at: 'Sequence' put: #('core').
	inputs at: 'Mode' put: #('html').
	inputs at: 'template' put: #('TextResult2.htm').
	inputs at: 'Language' put: (Array with: from, '/', to).
	scamperWindow _ (WebBrowser default ifNil: [^self]) newOrExistingOn: 'http://ets.freetranslation.com'.
	scamperWindow model submitFormWithInputs: inputs 
		url: 'http://ets.freetranslation.com:5081' asUrl
		method: 'post'.
	scamperWindow activate.
