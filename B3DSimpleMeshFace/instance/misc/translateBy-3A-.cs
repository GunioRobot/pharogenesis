translateBy: amount

	1 to: self size do:[:vertex | (self at: vertex) translateBy: amount].
  