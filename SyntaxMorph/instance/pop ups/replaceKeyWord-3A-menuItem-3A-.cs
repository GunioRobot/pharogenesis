replaceKeyWord: evt menuItem: stringMorph
	"Replace my entire message (which may be multi-part) with the one specified.  Preserve all argument tiles, either in the new message or in the world outside the scriptor.  I am a SelectorNode or KeyWordNode."

	| menu new news newSel mm newTree newRec newArgs top oldArgNodes share ctrY |
	(menu _ stringMorph owner owner) class == RectangleMorph ifTrue: [
		menu delete].
	new _ stringMorph contents.
	new first = $( ifTrue: [^ self].	"Cancel"
	new first = $  ifTrue: [^ self].	"nothing"
	news _ String streamContents: [:strm | "remove fake args"
		(new findBetweenSubStrs: #(' 5' $ )) do: [:part | strm nextPutAll: part]].
	newSel _ stringMorph valueOfProperty: #syntacticallyCorrectContents.
	newSel ifNil: [newSel _ news].
	mm _ MessageSend receiver: 5 selector: newSel 
			arguments: ((Array new: newSel numArgs) atAllPut: 5).
	newTree _ mm asTilesIn: Object globalNames: false.
	newRec _ newTree receiverNode.
	newArgs _ newTree argumentNodes.
	ctrY _ self fullBoundsInWorld center y.
	top _ self messageNode.
	newRec owner replaceSubmorph: newRec by: top receiverNode.
	oldArgNodes _ top argumentNodes.
	share _ newArgs size min: oldArgNodes size.
	(newArgs first: share) with: (oldArgNodes first: share) do: [:newNode :oldNode | 
		newNode owner replaceSubmorph: newNode by: oldNode].
	"later get nodes for objects of the right type for new extra args"

	top owner replaceSubmorph: top by: newTree.

	"Deposit extra args in the World"
	(oldArgNodes copyFrom: share+1 to: oldArgNodes size) do: [:leftOver |
		(leftOver parseNode class == LiteralNode and: [leftOver decompile asString = '5']) 
			ifFalse: [newTree pasteUpMorph addMorphFront: leftOver.
				leftOver position: newTree enclosingPane fullBoundsInWorld right - 20 @ ctrY.
				ctrY _ ctrY + 26]
			ifTrue: [leftOver delete]].
	newTree acceptIfInScriptor.