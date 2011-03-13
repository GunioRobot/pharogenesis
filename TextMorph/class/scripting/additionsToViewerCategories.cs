additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(
(text (
(slot characters	'The characters in my contents' string	readWrite player getCharacters player setCharacters:)
(slot firstCharacter  'The first character in my contents' string  readWrite player getFirstCharacter  player  setFirstCharacter:)
(slot allButFirst 'All my characters except the first one' string readWrite player getAllButFirstCharacter player  setAllButFirstCharacter:)
(slot numericValue 'The number represented by my contents' number readWrite player getNumericValue player  setNumericValue:)))

(basic (
(slot characters	'The characters in my contents' string	readWrite player getCharacters player setCharacters:))))


