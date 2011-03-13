named: aSymbol uses: aTraitCompositionOrCollection category: aString env: anEnvironment
	| trait oldTrait systemCategory |
	systemCategory _ aString asSymbol.
	trait _ anEnvironment
		at: aSymbol
		ifAbsent: [nil].
	oldTrait _ trait copy.
	trait _ trait ifNil: [super new].
	
	(trait isKindOf: Trait) ifFalse: [
		^self error: trait name , ' is not a Trait'].
	trait
		setName: aSymbol
		andRegisterInCategory: systemCategory
		environment: anEnvironment.
		
	trait setTraitComposition: aTraitCompositionOrCollection asTraitComposition.
	
	"... notify interested clients ..."
	oldTrait isNil ifTrue: [
		SystemChangeNotifier uniqueInstance classAdded: trait inCategory: systemCategory.
		^ trait].
	SystemChangeNotifier uniqueInstance traitDefinitionChangedFrom: oldTrait to: trait.
	systemCategory ~= oldTrait category 
		ifTrue: [SystemChangeNotifier uniqueInstance class: trait recategorizedFrom: oldTrait category to: systemCategory].
		
	^ trait