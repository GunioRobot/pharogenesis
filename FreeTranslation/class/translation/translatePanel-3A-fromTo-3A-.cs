translatePanel: buttonPlayer fromTo: normalDirection
	| ow fromTM toTM fromLang toLang tt doc answer width |
	"Gather up all the info I need from the morphs in the button's owner and do the translation.  Insert the results in a TextMorph.  Use www.freeTranslation.com Refresh the banner ad.
	TextMorph with 'from' in the title is starting text.
	PopUpChoiceMorph  with 'from' in the title is the starting language.
	TextMorph with 'from' in the title is place to put the answer.
	PopUpChoiceMorph  with 'from' in the title is the target language.
		If normalDirection is false, translate the other direction."

	ow _ buttonPlayer costume ownerThatIsA: PasteUpMorph.
	ow allMorphs do: [:mm |
		(mm isTextMorph) ifTrue: [ 
			(mm knownName asString includesSubString: 'from') ifTrue: [
				 fromTM _ mm].
			(mm knownName asString includesSubString: 'to') ifTrue: [
				 toTM _ mm]].
		(mm isKindOf: PopUpChoiceMorph) ifTrue: [ 
			(mm knownName asString includesSubString: 'from') ifTrue: [
				 fromLang _ mm contents asString].
			(mm owner knownName asString includesSubString: 'from') ifTrue: [
				 fromLang _ mm contents asString].
			(mm knownName asString includesSubString: 'to') ifTrue: [
				 toLang _ mm contents asString].
			(mm owner knownName asString includesSubString: 'to') ifTrue: [
				 toLang _ mm contents asString]]].
	normalDirection ifFalse: ["switch"
		tt _ fromTM.  fromTM _ toTM.  toTM _ tt.
		tt _ fromLang.  fromLang _ toLang.  toLang _ tt].
	Cursor wait showWhile: [
		doc _ self translate: fromTM contents asString from: fromLang to: toLang.
		answer _ self extract: doc].	"pull out the translated text"
	
	width _ toTM width.
	toTM contents: answer wrappedTo: width.
	toTM changed.