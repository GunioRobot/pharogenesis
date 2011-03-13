originalChangeSetForSelector: methodSelector
	"Returns the original changeset which contained this method version.  If it is contained in the .sources file, return #sources.  If it is in neither (e.g. its changeset was deleted), return nil.  (The selector is passed in purely as an optimization.)"

	| likelyChangeSets originalChangeSet |
	(file localName findTokens: '.') last = 'sources'
		ifTrue: [^ #sources].
	likelyChangeSets _ ChangeSet allChangeSets select: 
		[:cs | (cs atSelector: methodSelector class: self methodClass) ~~ #none].
	originalChangeSet _ likelyChangeSets
		detect: [:cs | cs containsMethodAtPosition: position]
		ifNone: [nil].
	^ originalChangeSet  "(still need to check for sources file)"