removeClassFromSystem: aClass logged: aBool
	"Delete the class, aClass, from the system, but log the removal neither to the current change set nor to the changes log"
	self deprecated: 'This method has been renamed because using it directly was usually insufficient (and a bug). You probably want to use aClass removeFromSystem, and that is what happens if you proceed. If you''re sure you want to remove the class from various registries but not do other finalization, call the method SystemDictionary>>forgetClass:logged:.'.
	^aClass removeFromSystem.
