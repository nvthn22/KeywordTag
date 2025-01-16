function ErrorBoundary(props) {

    function getDerivedStateFromError(error) {
        return { hasError: true };
    }

    function componentDidCatch(error, errorInfo) {
        console.log(error);
        console.log(errorInfo);
    }

    return (
        <>
            Có lỗi xảy ra, vui lòng thử lại.
        </>
    )
}

export default ErrorBoundary
