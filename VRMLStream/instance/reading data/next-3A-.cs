next: anInteger
   | array |
array _ String new: anInteger.
    1 to: anInteger do: [:i |
        array at: i put: self next].
    ^ array