width: x height: y type: class
    "Set the number of elements in the first and
    second dimensions.  class can be Array or String or ByteArray."

    contents == nil ifFalse: [self error: 'No runtime size change yet'].
        "later move all the elements to the new sized array"
    width _ x.
    contents _ class new: width*y.