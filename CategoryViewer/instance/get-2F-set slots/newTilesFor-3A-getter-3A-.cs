newTilesFor: aPlayer getter: aSpec
	| ms argTile argArray |
	"Return universal tiles for a getter on this property.  Record who self is."

	ms _ MessageSend receiver: aPlayer selector: aSpec seventh arguments: #().
	aSpec second == #colorSees ifTrue: [
		ms selector: #color:sees:.
		argTile _ aPlayer tileForArgType: #color inViewer: nil.
		argArray _ Array with: argTile colorSwatch color with: argTile colorSwatch color copy. 
		ms arguments: argArray].
	aSpec second == #isOverColor ifTrue: [
		ms selector: #seesColor:.
		argTile _ aPlayer tileForArgType: #color inViewer: nil.
		ms arguments: (Array with: argTile colorSwatch color)].
	aSpec second == #touchesA ifTrue: [
		ms selector: #touchesA:.
		argTile _ aPlayer tileForArgType: #player inViewer: nil.
		ms arguments: (Array with: argTile actualObject)].
	^ ms asTilesIn: aPlayer class