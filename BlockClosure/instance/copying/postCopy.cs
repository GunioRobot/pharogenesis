postCopy
	"To render a copy safe we need to provide a new outerContext that
	 cannot be returned from and a copy of any remoteTemp vectors.
	 When a block is active it makes no reference to state in its nested
	 contexts (this is the whole point of the indirect temps scheme; any
	 indirect state is either copied or in indirect temp vectors.  So we
	 need to substitute a dummy outerContext and copy the copiedValues,
	 copying anything looking like a remote temp vector.  if we accidentally
	 copy an Array that isn't actually an indirect temp vector we do extra work
	 but don't break anything."

	outerContext := MethodContext
						sender: nil
						receiver: outerContext receiver
						method: outerContext method
						arguments: #().
	self fixTemps