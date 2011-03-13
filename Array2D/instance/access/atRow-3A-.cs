atRow: j
    "Fetch a whole row.  6/20/96 tk"

    ^ contents copyFrom: (j - 1) * width + 1 to: (j) * width