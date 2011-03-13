assuredCostumee
	"Answer the receiver's costumee, a Player,, creating a new one if none currently exists"
	costumee ifNil:
		[self externalName.  "a default may be given if not named yet"
		costumee _ self newPlayerInstance.  "Different morphs may demand different player types"
		costumee costume: self.
		self world flushPlayerListCache].
	^ costumee
