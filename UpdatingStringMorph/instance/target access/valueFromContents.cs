valueFromContents
	"Return a new value from the current contents string."

	format = #string ifTrue: [^ contents].
	^ Compiler evaluate: contents
