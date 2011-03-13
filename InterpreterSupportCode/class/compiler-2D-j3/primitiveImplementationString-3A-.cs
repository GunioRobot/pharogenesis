primitiveImplementationString: tricky	"InterpreterSupportCode primitiveImplementationString: self trickyPrimitiveList"
	"Answer the contents of the primitives.cc file."

	^String streamContents: [:file |
		file nextPutAll: '// primitives.cc -- primitive characteristics'; cr;
			nextPutAll: '//'; cr;
			nextPutAll: '// WARNING: this file was generated automatically -- DO NOT EDIT!'; cr;
			nextPutAll: '//'; cr;
			nextPutAll: '// Author: Squeak2.7 (on behalf of Ian.Piumarta@INRIA.Fr)'; cr;
			nextPutAll: '//'; cr;
			nextPutAll: '// Last edited: NEVER (and woebetide anybody who dares to!)'; cr; cr;
			nextPutAll: '#include "primitive.h"'; cr; cr.
		self nextPutFlagsDefinition: tricky on: file.
		file cr.
		self nextPutPrimitiveTable: tricky on: file.
	]