buildActors
	"Using the given VRML scene build a set of actors for Wonderland"
	attributes _ Dictionary new.
	Utilities informUserDuring:[:bar| 
		progress _ bar.
		scene doWith: self].