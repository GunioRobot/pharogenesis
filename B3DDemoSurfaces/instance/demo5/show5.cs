show5

    " B3DDemoSurfaces new show5"

     | view |

  self createScene5.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene5;
     scene: scene.
  view clearColor: (Color gray: 0.86).

  
  view openInSystemWindow