additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(
(#'color & border' (
(slot backgroundColor 'The color of the background behind the text' Color readWrite Player getBackgroundColor Player setBackgroundColor:)))

(text (
(slot backgroundColor 'The color of the background behind the text' Color readWrite Player getBackgroundColor Player setBackgroundColor:)
(slot characters	'The characters in my contents' String	readWrite Player getCharacters Player setCharacters:)

(slot cursor 'The position among my characters that replacement text would go' Number readWrite Player getCursor Player setCursor:)
(slot characterAtCursor 'The character at the my cursor position' String readWrite Player getCharacterAtCursor Player setCharacterAtCursor:)
(slot count 'How many characters I have' Number readOnly Player getCount unused unused)

(slot firstCharacter  'The first character in my contents' String  readWrite Player getFirstCharacter  Player  setFirstCharacter:)

(slot lastCharacter  'The last character in my contents' String  readWrite Player getLastCharacter  Player  setLastCharacter:)
(slot allButFirst 'All my characters except the first one' String readWrite Player getAllButFirstCharacter Player  setAllButFirstCharacter:)
(command insertCharacters: 'insert the given string at my cursor position' String)
(command insertContentsOf: 'insert the characters from another object at my cursor position' Player)
(slot numericValue 'The number represented by my contents' Number readWrite Player getNumericValue Player  setNumericValue:)))

(basic (
(slot characters	'The characters in my contents' String	readWrite Player getCharacters Player setCharacters:))))


