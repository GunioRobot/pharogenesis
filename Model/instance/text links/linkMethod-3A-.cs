linkMethod: classAndMethod
	"Make a linked message list and put this method in it"
	| list |
	list _ OrderedCollection new.
	list add: classAndMethod.
	LinkedMessageSet openMessageList: list name: 'Linked by HyperText'.