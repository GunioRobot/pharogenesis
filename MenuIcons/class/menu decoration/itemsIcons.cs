itemsIcons
	"answer a collection of associations wordings -> icon to decorate 
	the menus all over the image"
	| icons |
	icons := OrderedCollection new.
	" 
	world menu"
	icons add: #('previous project' ) -> self backIcon.
	icons add: #('jump to project...' ) -> self forwardIcon.
	icons add: #('open...' ) -> self openIcon.
	icons add: #('appearance...' ) -> self appearanceIcon.
	icons add: #('help...' ) -> self helpIcon.
	icons add: #('windows...' ) -> self windowIcon.
	icons add: #('print PS to file...' ) -> self printIcon.
	icons add: #('save' 'save project on file...' ) -> self saveIcon.
	icons add: #('save as...' 'save as new version' ) -> self saveAsIcon.
	icons add: #('quit' 'save and quit' ) -> self quitIcon.
	""
	icons add: #('do it (d)' ) -> self doItIcon.
	icons add: #('inspect it (i)' 'explore it (I)' 'inspect world' 'explore world' 'inspect model' 'inspect morph' 'explore morph' 'inspect owner chain' 'explore' 'inspect' 'explore (I)' 'inspect (i)' 'basic inspect' ) -> self inspectIcon.
	icons add: #('print it (p)' ) -> self printIcon.
	""
	icons add: #('copy (c)' ) -> self copyIcon.
	icons add: #('paste (v)' 'paste...' ) -> self pasteIcon.
	icons add: #('cut (x)' ) -> self cutIcon.
	""
	icons add: #('accept (s)' ) -> self okIcon.
	icons add: #('cancel (l)' ) -> self cancelIcon.
	""
	icons add: #('do again (j)' ) -> self redoIcon.
	icons add: #('undo (z)' ) -> self undoIcon.
	""
	icons add: #('find...(f)' 'find again (g)' 'find class... (f)' 'find method...' ) -> self findIcon.
	""
	icons add: #('remove' 'remove class (x)' 'delete method from changeset (d)' 'remove method from system (x)' 'delete class from change set (d)' 'remove class from system (x)' 'destroy change set (X)' ) -> self deleteIcon.
	icons add: #('add item...' 'new category...' ) -> self newIcon.
	""
	icons add: #('new morph...' 'objects (o)' ) -> self morphsIcon.
	""
	^ icons