imageMorphFrom: formKey
	"Add the supplied form as a graphical handle centered at the given point.  Return the handle."
	| aForm |
	aForm _ (ScriptingSystem formAtKey: formKey) ifNil: [ScriptingSystem formAtKey: #SolidMenu].
	^ ImageMorph new image: aForm; extent: aForm extent; yourself
