addIconiseButton
"we need a iconise button on the window. If there is already one, ignore this. 
If the host window does not yet exist we need only set the flag. If there is
already a window, we will need to destroy the old window, add the flag and recreate"

	^self addButton: IconiseButton