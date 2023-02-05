
export function italic()
{
    document.getElementById("text-area").style.fontStyle = "italic"
}

export function normal()
{
    document.getElementById("text-area").style.fontStyle = "normal"
    document.getElementById("text-area").style.fontWeight = "normal"
}

export function bold()
{
    document.getElementById("text-area").style.fontWeight = "bold"
}

export function alert(str)
{
    alert(str)
}