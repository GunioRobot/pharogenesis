checkForConversionMethods
	"See if any conversion methods are needed"

	| needConversion oldList newList tell choice list need oldVer newVer
sel smart restore |
	"Check preference"
	Preferences conversionMethodsAtFileOut ifFalse: [^ self].
	structures ifNil: [^ self].

	needConversion _ false.
	list _ OrderedCollection new.
	smart _ SmartRefStream on: (RWBinaryOrTextStream on: '12345').
	self changedClasses do: [:class |
		need _ (self atClass: class includes: #new) not.
		need ifTrue: [
			"Also consider renamed classes."
			(self atClass: class includes: #rename) ifTrue: [
				needConversion _ true.  list add: class].
			need _ (self atClass: class includes: #change)].
		need ifTrue: [oldList _ structures at: class name 
								ifAbsent: [need _ false.  #()]].
		need ifTrue: [
			newList _ (Array with: class classVersion), (class allInstVarNames).
			need _ (oldList ~= newList)].
		need ifTrue: [
			oldVer _ smart versionSymbol: oldList.
			newVer _ smart versionSymbol: newList.
			sel _ 'convert',oldVer,':',newVer, ':'.	
			(Symbol hasInterned: sel ifTrue: [:ignored |]) ifFalse: [
				need _ false.
				needConversion _ true.
				list add: class]].
		need ifTrue: [sel _ sel asSymbol.
			(#(add change) includes: (self atSelector: sel class: class))
ifFalse: [
				needConversion _ true.
				list add: class]].
		].

	needConversion ifTrue: ["Ask user if want to do this"
		tell _ 'If there might be instances of ', list asArray printString,
		'\in a file full of objects on someone''s disk, please fill in
conversion methods.\'
			withCRs,
		'After you edit the methods, you''ll have to fileOut again.\' withCRs,
		'The preference conversionMethodsAtFileOut controls this feature.'.
		choice _ (PopUpMenu labels: 
'Write a conversion method by editing a prototype
These classes are not used in any object file.  fileOut my changes now.
I''m too busy.  fileOut my changes now.
Don''t ever ask again.  fileOut my changes now.') startUpWithCaption:
tell. 
		choice = 4 ifTrue: [Preferences disable: #conversionMethodsAtFileOut].
		choice = 2 ifTrue: [
				list do: [:cls | cls withAllSubclassesDo: [:ccc | 
						structures removeKey: ccc name ifAbsent: []]]].
		choice ~= 1 ifTrue: [^ self]].

	list isEmpty ifTrue: [^ self].
	smart structures: structures.	"we will test all classes in structures."
	smart superclasses: superclasses.
	(restore _ Smalltalk changes) == self ifFalse: [
		Smalltalk newChanges: self].
	[smart verifyStructure = 'conversion method needed'] whileTrue.
		"new method is added to changeSet.  Then filed out with the rest."
	restore == self ifFalse: [Smalltalk newChanges: restore].
	"tell 'em to fileout again after modifying methods."
	self inform: 'Remember to fileOut again after modifying these
methods.'.