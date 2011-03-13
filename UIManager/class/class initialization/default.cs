default
	| mgrClass |
	^Default ifNil:[
		"Note: The way the following is phrased ensures that you can always make 'more specific' managers merely by subclassing a tool builder and implementing a more specific way of reacting to #isActiveManager. For example, a BobsUIManager can subclass MorphicUIManager and (if enabled, say Preferences useBobsUI) will be considered before the parent (generic MorphicUIManager)."
		mgrClass := self allSubclasses 
			detect:[:any| any isActiveManager and:[
				any subclasses noneSatisfy:[:sub| sub isActiveManager]]] ifNone:[nil].
		mgrClass ifNotNil:[mgrClass new]
	].